# Loan-Management---ASP.NET

## Description

**In today's fast-paced world, people and companies alike need financial support. Loans serve an important part in meeting personal bills, education, and business investments. However, applying for and maintaining loans may be difficult, time-consuming, and prone to mistakes. To solve these issues, we provide the Loan Application and Management System, a novel solution that streamlines the loan application process, increases transparency, and boosts efficiency for both applicants and lenders. This system uses cuttingedge technology to automate every stage of the loan lifecycle, from application submission to approval and repayment management.**

## User

* **Admin**
* **Loan Officer**
* **Applicant**

## Database Design

### **1. Users**

* **userID (PK)**
* **username**
* **password**
* **FullName**
* **Email**
* **ContactNumber**
* **Role (Enum: Admin, Loan Officer, Applicant)**
* **DateCreated**

### **2. LoanApplications**

* **ApplicationID (PK)**
* **LoanAmount**
* **ApplicationStatus (Enum: Pending, Approved, Rejected)**
* **AppliedDate**
* **DecisionDate**
* **ApplicantID (FK to Users.userID)**
* **ProductID (FK to LoanProduct.ProductID)**

### **3. LoanProduct**

* **ProductID (PK)**
* **ProductName**
* **InterestRate**
* **TermMonths**
* **EligibilityCriteria**

### **4. Reminders**

* **ReminderID (PK)**
* **ReminderType**
* **Message**
* **ReminderDate**
* **Status (Enum: Active, Completed)**
* **UserID (FK to Users.userID)**

### **5. ApplicationFeedback**

* **FeedbackID (PK)**
* **ApplicationID (FK to LoanApplications.ApplicationID)**
* **ApplicantID (FK to Users.userID)**
* **FeedbackText**
* **DateSubmitted**


