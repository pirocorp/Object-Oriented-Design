namespace DomainEvents.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DomainEvents.Interfaces;

using MediatR;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
{
    private readonly IMediator mediator;
    private readonly Dictionary<Guid, TEntity> entities;

    public Repository(IMediator mediator)
    {
        this.mediator = mediator;
        this.entities = new Dictionary<Guid, TEntity>();
    }

    public TEntity GetById(Guid id)
        => this.entities[id];

    public List<TEntity> GetAll()
        => this.entities.Values.ToList();

    public async Task Save(TEntity entity)
    {
        this.entities[entity.Id] = entity;
        ConsoleWriter.FromRepositories("[DATABASE] Saved entity {0}", entity.Id.ToString());

        var eventsCopy = entity.Events.ToArray();
        entity.Events.Clear();

        foreach (var domainEvent in eventsCopy)
        {
            await this.mediator.Publish(domainEvent).ConfigureAwait(false);
        }
    }
}
