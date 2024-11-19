
# **ARCHITECTURE.md**

## **Overview**
The `please.` app is designed to track meals, exercises, and user progress while offering flexibility for future enhancements such as AI-driven insights. It follows modern design principles, prioritizing modularity, scalability, and user-centric performance.

---

## **Architecture Design**

### **1. Layered Architecture**
The app is built using a layered architecture:
- **UI Layer**: Handles user interactions and displays data using .NET MAUI with MVVM.
- **Business Logic Layer**: Encapsulates app-specific logic, such as meal and exercise calculations.
- **Data Layer**: Manages local (Realm) and cloud (MongoDB Atlas) databases, ensuring offline-first functionality.

---

## **Styling Choices**

### **Initial Consideration: Xamarin.Forms Visual Material**
Visual.Material was evaluated for its ability to provide consistent, polished styles across platforms based on Google’s Material Design guidelines. 

#### **Pros of Visual.Material**:
- Prebuilt styles simplify development for buttons, inputs, and basic components.
- Provides uniformity across Android, iOS, and Windows.
- Ideal for form-heavy applications or apps that align closely with Material Design principles.

#### **Limitations for This App**:
1. **Custom Layout Needs**:
   - The app heavily relies on custom components like cards for meal tracking, macros, and timelines, which require more flexibility than Visual.Material offers.

2. **Styling Flexibility**:
   - Customizations in Material-styled controls are limited, making it less ideal for highly tailored designs.

3. **Focus on Interactivity**:
   - Visual.Material is better suited for apps with forms and navigational inputs rather than highly visual, card-based layouts.

#### **Final Decision**:
Visual.Material was not chosen due to the app’s emphasis on custom visuals and layouts. Instead, **CommunityToolkit.Maui** and custom XAML styles were selected to better support the design and interaction goals.

---

### **Chosen Styling Approach**

#### **1. CommunityToolkit.Maui**
- Provides essential controls like `Expander`, `Snackbar`, and `TabView`.
- Lightweight and free, aligning with the app’s modular architecture.
- Works well with the custom card and timeline components envisioned in the designs.

#### **2. Custom XAML Styles**
- Custom styles and `ResourceDictionaries` allow for tailored designs.
- Example: Card styles for meal details or macro breakdowns.

#### **3. Lucide Icons**
- SVG-based icon library adds modern visuals for meals, exercises, and progress indicators.

#### **Future Styling Enhancements**:
- Explore third-party libraries like **Syncfusion** for advanced visualizations (if budget permits).
- Incorporate additional animations and transitions for a smoother user experience.

---

## **State Management Patterns**

### **1. MVVM (Model-View-ViewModel)**
The app uses **MVVM** to manage UI state and interactions. This pattern is chosen because:
- It simplifies two-way data binding in .NET MAUI.
- Promotes clear separation of concerns between the UI (View) and business logic (ViewModel).
- Reduces boilerplate code using `CommunityToolkit.Mvvm`.

**MVVM Flow**:
- **Model**: Represents data structures like meals, exercises, and daily progress.
- **ViewModel**: Manages state, user commands, and interaction logic.
- **View**: XAML pages displaying data and responding to user interactions.

---

### **2. MVU (Model-View-Update)**
While MVU is a reactive pattern suitable for highly dynamic UIs, it was not chosen due to:
- Limited tooling support in .NET MAUI.
- Steeper learning curve compared to MVVM.
- Additional complexity for managing larger application states.

---

### **3. WPF/Redux-Like State Management**
A Redux-like pattern using a global state store was also considered. It offers:
- Centralized state management.
- Simplified debugging with a single source of truth.

However, this was not implemented as it introduces:
- Excessive boilerplate for smaller apps.
- Overhead for scenarios where View-ViewModel communication is sufficient.

---

# **Comparison Table of State Management Patterns**

| **Feature**               | **MVU**                        | **MVVM**                       | **WPF State Management**        |
|---------------------------|---------------------------------|---------------------------------|----------------------------------|
| **Learning Curve**         | Moderate (reactive pattern).   | Easy (familiar to most devs).   | Steep (requires Redux-like concepts). |
| **Code Simplicity**        | Cleaner for small apps.         | Moderate (requires bindings).   | Higher boilerplate.             |
| **State Sharing**          | Difficult without extensions.   | Works well for View-ViewModel.  | Best for global state.          |
| **Tooling Support**        | Limited.                       | Strong (built into .NET).       | Weak (custom setup needed).     |
| **Performance**            | Excellent for reactive UIs.     | Excellent for structured UIs.   | Moderate (depends on store size).|
| **Best For**               | Highly reactive UIs.           | Traditional XAML apps.          | Global state sharing across views.|

---

## **Future Considerations**
1. **Scalability**:
   - Transition to Redux-like state management if global state sharing becomes critical.
   - Use Azure Cosmos DB for distributed, scalable storage.

2. **Performance**:
   - Optimize Realm and MongoDB queries for large datasets.
   - Consider data virtualization techniques for UI performance with large lists.

3. **AI Integration**:
   - Leverage Azure Cognitive Services for predictive meal and exercise suggestions.

---

## **Conclusion**
The chosen architecture ensures simplicity for the MVP while allowing seamless scaling and feature enhancements for future iterations.

Comparison Table
Feature	MVU	MVVM	WPF State Management
Learning Curve	Moderate (reactive pattern).	Easy (familiar to most devs).	Steep (requires Redux-like concepts).
Code Simplicity	Cleaner for small apps.	Moderate (requires bindings).	Higher boilerplate.
State Sharing	Difficult without extensions.	Works well for View-ViewModel.	Best for global state.
Tooling Support	Limited.	Strong (built into .NET).	Weak (custom setup needed).
Performance	Excellent for reactive UIs.	Excellent for structured UIs.	Moderate (depends on store size).
Best For	Highly reactive UIs.	Traditional XAML apps.	Global state sharing across views.
