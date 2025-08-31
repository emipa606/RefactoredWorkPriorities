# GitHub Copilot Instructions for Refactored Work Priorities (Continued)

## Mod Overview and Purpose
Refactored Work Priorities (Continued) is a mod for RimWorld aimed at enhancing the player's control over colonist work priorities and schedules. Originally created by Dingo and updated for compatibility with version B18, the mod introduces new functionality to modify how colonists prioritize tasks. It includes a customizable options menu within the game's Mod Settings to tweak these settings to your preference.

## Key Features and Systems
- **Enhanced Work Priority Management**: Introduces more granular control over colonists' work routines and processes.
- **Feeding Injured Animals**: Handlers will prioritize feeding injured animals instead of doctors.
- **Roof Construction Prioritization**: Removal of roofs is prioritized over building new roofs.
- **Custom Repair Threshold**: Players can set specific thresholds for when repairs should be started on structures.
- **Repair Designator Tool**: Tool to force repairs on buildings that exceed the set repair threshold.
- **Prioritization of Hauling Tasks**: Handle perishable and deteriorating items with higher urgency compared to other tasks.
- **Item Condition Filtering**: Set item health thresholds to avoid prioritizing low HP items.

## Coding Patterns and Conventions
- **Class Naming**: Classes use the PascalCase naming convention, consistent with C# standards (e.g., `Controller`, `Designator_ForcedRepair`).
- **Inheritance**: Derived classes extend base classes with specific functionality, as seen in `WorkGiver_HaulDeteriorating` which extends `WorkGiver_HaulGeneral`.
- **Modular Classes**: Each class encapsulates a specific functionality, aiding in readability and maintainability.
- **Public Accessibility**: Classes and methods are public to ensure accessibility across different parts of the mod.

## XML Integration
The mod leverages RimWorld's XML-based configuration files to define and extend in-game content like work types and priorities. Ensure that XML entries are properly referenced and aligned with your C# components to trigger the desired in-game behaviors.

## Harmony Patching
- The mod uses Harmony to patch methods and enhance or alter existing game functionalities.
- Ensure that your Harmony patches are correctly identified using method names and types, and always test patches to prevent conflicts.
- Use Harmony's `Prefix` and `Postfix` attributes to insert code before or after the original methods respectfully.

## Suggestions for Copilot
- **Auto-completion**: Utilize Copilot for quickly generating repetitive code blocks like getters, setters, and initialization.
- **Pattern Recognition**: Leverage Copilot to identify commonly used coding patterns within your classes and methods for better consistency.
- **Error Handling**: Use Copilot to assist with try-catch blocks and error handling mechanisms while following best practices for robust code.
- **XML Template Suggestions**: Employ Copilot to generate XML templates quickly to save time on repetitive XML entries and configuration tasks.
- **Harmony Patch Enhancement**: Rely on Copilot to suggest improvements and optimizations for Harmony patches to maintain high performance and compatibility.

By following these guidelines, you can effectively utilize GitHub Copilot to enhance the development and maintenance of the Refactored Work Priorities (Continued) mod.
