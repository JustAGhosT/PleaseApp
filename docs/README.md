
# **please. App**

The `please.` app is a cross-platform health improvement tool designed to track meals, exercises, and overall user progress. Built with **.NET MAUI** for native mobile and desktop support, the app leverages modern technologies like **Realm**, **MongoDB Atlas**, and **Azure services** for a seamless offline-first experience with cloud sync capabilities.

---

## **Key Features**
1. **Meal Tracking**: Log daily meals with macro breakdowns (Carbs, Protein, Fats).
2. **Exercise Logging**: Track workout routines categorized by type (Cardio, Strength, Mobility).
3. **Offline-First**: Use Realm for local storage, with syncing to MongoDB Atlas for cloud persistence.
4. **Customizable Plans**: Predefined schedules with the ability to swap ingredients or routines.
5. **Visual Progress**: Interactive charts to track calories and workout progress.
6. **User Authentication**: Secure login via Azure AD B2C.
7. **Future AI Features**: Predictive recommendations for meals and exercises based on user data.

---

# **Technologies and Frameworks**

| **Category**             | **Technology/Framework**      | **Purpose**                                                        |
|--------------------------|-------------------------------|--------------------------------------------------------------------|
| **Frontend Framework**    | .NET MAUI                    | Cross-platform app development for mobile and desktop.             |
| **Architecture**          | .NET Aspire                  | Lightweight architectural framework for modular, scalable design.  |
| **Combined Approach**     | .NET Aspire + .NET MAUI      | Start with MAUI for frontend, extend with Aspire for backend modularity. |
| **State Management**      | MVVM (CommunityToolkit.Mvvm) | Simplifies data binding and logic separation for UI components.    |
| **Local Database**        | Realm                        | Offline-first object database for storing meals and exercises.     |
| **Cloud Database**        | MongoDB Atlas                | Synchronizes data across devices and stores logs for analysis.     |
| **Styling**               | CommunityToolkit.Maui        | Provides enhanced UI components like `Expander` and `Snackbar`.    |
| **Icons**                 | Lucide Icons                 | Modern SVG-based icons for visual enhancements.                    |
| **Authentication**        | Azure AD B2C                 | Secure user authentication and authorization.                      |
| **Charting**              | LiveCharts2                  | Free, open-source charting library for data visualization.         |
| **AI Services**           | Azure Cognitive Services     | Enables predictive recommendations and sentiment analysis.         |
| **Testing**               | MSTest, xUnit, NUnit         | Frameworks for unit, integration, and UI testing.                  |

---

## **What is .NET Aspire?**
.NET Aspire is a lightweight architectural framework designed to simplify the development of scalable and modular .NET applications. It focuses on:
- **Simplicity**: Reduces boilerplate code and accelerates development for small-to-medium projects.
- **Modularity**: Encourages breaking down functionality into manageable components.
- **Scalability**: Easily adaptable to larger systems as the application evolves.
- **Compatibility**: Works seamlessly with .NET-based tools and frameworks, making it suitable for projects leveraging .NET MAUI.

.NET Aspire ensures a balance between rapid prototyping and maintainability, making it a great fit for MVPs and expanding applications like the `please.` app.

---

## **How .NET Aspire and .NET MAUI Work Together**

1. **Start with .NET MAUI** for building the **frontend prototype**:
   - Focus on user experience with responsive UIs for meal tracking, progress visuals, and customization.
   - Use **Realm** for local data storage, ensuring offline-first functionality.

2. **Extend with .NET Aspire** for backend modularity:
   - Add scalable backend architecture with modular services for syncing meals, exercises, and user data.
   - Design RESTful APIs to integrate with **MongoDB Atlas** or **Azure Functions**.

3. **Scaling and Future Enhancements**:
   - Utilize **Azure Cognitive Services** for AI-driven recommendations.
   - Transition from a local-first to a cloud-connected app seamlessly using Aspire principles.

---

## **Setup Instructions**

### Prerequisites
1. Install **.NET 6+**: [dotnet.microsoft.com](https://dotnet.microsoft.com/).
2. Install **Node.js**: Required for frontend dependencies.
3. Configure **MongoDB Realm** and **Azure AD B2C** (for sync and authentication).

### **1. Clone the Repository**
```bash
git clone https://github.com/yourusername/please-app.git
cd please-app
```

### **2. Install Dependencies**

#### Backend
```bash
dotnet restore
```

#### Frontend (Tailwind CSS - if applicable)
```bash
npm install
npx tailwindcss init
```

### **3. Run the App**
- **MAUI App**:
```bash
dotnet build
dotnet run
```

---

## **Next Steps**
1. Confirm installation of **.NET MAUI templates**:
   ```bash
   dotnet workload install maui
   ```
2. Begin development with local data storage using **Realm**.

---

## **Folder Structure**
Refer to the [FOLDER_STRUCTURE.md](FOLDER_STRUCTURE.md) for detailed folder organization.

---

## **Contributing**
We welcome contributions to enhance the app! Follow these steps:
1. Fork the repository.
2. Create a new branch for your feature:
   ```bash
   git checkout -b feature/your-feature
   ```
3. Commit and push your changes.
4. Submit a pull request.

---

## **License**
This project is licensed under the MIT License. See the `LICENSE` file for details.
