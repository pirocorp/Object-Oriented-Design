namespace ObjectPool.GenericPool.Loader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Store;

    using static ErrorMessages;

    internal class LoaderFactory
    {
        public static ILoader CreateLoader(LoadingMode loading, AccessMode access)
        {
            switch (loading)
            {
                case LoadingMode.Eager:
                    return new EagerLoading();
                case LoadingMode.Lazy:
                    if (access == AccessMode.Circular)
                    {
                        return new LazyExpanding();
                    }

                    return new LazyLoader();
                default:
                    throw new ArgumentOutOfRangeException(nameof(loading), loading, UnsupportedLoaderMode);
            }
        }
    }
}
