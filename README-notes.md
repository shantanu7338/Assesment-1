-- Backend Implementation

On the backend side, first I created separate DTO files to keep the controller clean and maintain proper project structure.

Then I implemented a service-based architecture.
I created an interface called ICommissionCalculatorService and defined a method CalculateCommission.
After that, I created a concrete service class CommissionCalculatorService which implements this interface and contains the actual business calculation logic.

To enable dependency injection, I registered this service inside Program.cs using AddScoped.

Since the React application and the API are running on different origins, I also configured CORS policy in the backend to allow requests from the React application.

This helped in maintaining separation of concerns, better testability, and cleaner controller logic.

-- Frontend Implementation

On the frontend side, in the App.js file, I modified the handleSubmit method.
I removed the client-side commission calculation logic and instead integrated a Fetch API call to the backend endpoint.

After receiving the response from the API, I mapped the returned commission data to the UI state and displayed the results with proper labels and formatting.

This approach ensures that the business logic is centralized in the backend, while the frontend is responsible only for user interaction and presentation.