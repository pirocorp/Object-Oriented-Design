# Null Object Pattern

The intent of this pattern is to reduce the need to add checks and special behavior for handling null instances of certain variables that tend to propagate through applications. Rather, identify the behavior that should occur when a null is encountered, encapsulate this behavior into an instance of the type in question, and define this instance as a special, constant value of that type. 

For instance, consider a call center application that looks up customers based on their phone number:

```csharp
public Customer GetByPhoneNumber(string phoneNumber)
{
  return _customerRepository
         .List(c => c.PhoneNumber == phoneNumber)
         .FirstOrDefault();
}
```

Now imagine that elsewhere the application needs to display some details about the customer that was found, such as their total number of orders and amount spent. The application will need to be careful to check for null:

```csharp
var customer = GetByPhoneNumber(phone);

int orderCount = customer != null ? customer.OrderCount : 0;
decimal totalPurchase = customer != null ? customer.TotalPurchase : 0m;
```

This kind of code gets even more verbose if full if blocks are used, and it's very easy to miss a check, in which case a runtime null reference exception is likely.

To implement the Null Object Pattern, an instance of Customer is created to represent the case of a "not found" customer:

```csharp
public class Customer
{
  public static Customer NotFound =
     new Customer() { OrderCount=0, TotalSales=0m };

  // other properties and behavior
}
```

Another way implement the Null Object Pattern, is by using inheritance:

```csharp
public class NullObjectCustomer : Customer
{
  public NullObjectCustomer(){
    OrderCount=0;
    TotalSales=0m;
  }
  // other properties and behavior
}
```

Then, wherever you would have a method that could return a null Customer, have it return the static instance instead:

```csharp
public Customer GetByPhoneNumber(string phoneNumber)
{
 var customer = _customerRepository
                .List(c => c.PhoneNumber == phoneNumber)
                .FirstOrDefault();
  if(customer == null) { return Customer.NotFound; }
  return customer;
}
```

If using `NullObjectCustomer`, code is the same, except for:

```csharp
return new NullObjectCustomer();
```

Once the Null Object Pattern is in place, there is no need to even have the local variables (orderCount, totalPurchase) shown in the example above, as they only existed because the customer instance might be null. Likewise, their null checks aren't needed - overall the client code is simpler, and probably has less duplicate code, since frequently these kinds of null checks proliferate throughout the code base (this is symptomatic of the fact that nulls violate the [Liskov Substitution Principle](https://github.com/pirocorp/Object-Oriented-Design/blob/main/10.%20SOLID/liskov-substitution-principle-slides.pdf).
















