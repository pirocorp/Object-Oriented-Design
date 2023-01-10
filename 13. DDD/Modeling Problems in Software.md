# Modeling Problems in Software


## Breaking up the veterinary office domain

### Planning Ahead to Learn About the Domain

Goals for Learning About the Domain
  - Understand client’s business
  - Identify processes beyond project scope
  - Look for subdomains we should include
  - Look for subdomains we can ignore

### Conversation with a Domain Expert: Exploring the Domain and Its Subdomains

Learning about the Complete Domain
  - **Patient scheduling**
  - **Owner and pet data management**
  - Billing (External?)
  - **Surgery scheduling**
  - **Office visit data collection**
  - Sales and Inventory
  - Lab testing (schedule, results, bill)
  - Prescriptions
  - Staff scheduling
  - CMS (External?)  

Some of the Identified Subdomains
  - Staff
  - Accounting
  - Client and patient records
  - Visit records
  - Appointment scheduling
  - Sales
  
### Conversation with a Domain Expert: Exploring the Scheduling Subdomain
  
Continued Deep Collaboration with Domain Experts. Notes from Our Conversations.
  - Clients (people) schedule appointments for patients (pets)
  - Appointments may be either office visits or surgeries
  - Office visits may be an exam requiring a doctor, or a tech visit
  - Office visits depend on exam room availability
  - Surgeries depend on O/R and recovery space availability, and can involve different kinds of procedures
  - Different appointment types and procedures require different staff

> Learn and communicate in the language of the domain, not the language of technology.


### More Questions for a Domain Expert

- Any chance of concurrency conflicts? 
  - Doesn’t anticipate being big enough to have this problem any time soon.
- Do you need to schedule rooms and staff when you schedule an appointment? Dependencies?
  - Room + tech OR…
  - Room + doctor OR…
  - Room + doctor + tech 
- Does “resources” work as an umbrella term for them?
  - Yes!


### Reviewing Key Takeaways from Meeting with Domain Expert(s)

Key Takeaways From the Customer Conversation

-  Patients and clients are not the same thing to a veterinarian.
-  Important to get on the “same page” with the domain expert.
-  The customer gained better understanding of their own business process by describing it in terms we could understand and model.
-  Avoid speaking in programmer terms.
-  At this stage, the focus is on how the domain works, not how the software will work.
-  Make the implicit knowledge of domain experts explicit.

> As software developers, we fail in two ways: We build the thing wrong, or We build the wrong thing.

Steve Smith


### Taking a First Pass at Modeling our Subdomain

The central concept in this application is the **Appointment** itself. Typically the **Appointment** is scheduled by the **Client** for a **Patient**. Often booking an **Appointment** requires an **Exam Room** and a **Doctor**, but it may involve other resources.

**Appointments** may be for office visits or vaccinations, or they may be **Surgeries** which are separate kinds of things entirely with their own rules. They involve different kinds of **Procedures**. **Surgeries** require different **Resources**, too, like **Operating Room** and **Recovery Room**.

![image](https://user-images.githubusercontent.com/34960418/211534635-00a634e0-5c7d-45a7-b710-44a79bb10f27.png)



## The importance of the domain experts



## A play! (Discovering the domain )



## Core elements of a domain model



## Subdomains and bounded contexts



## That ubiquitous term: ubiquitous language
