# GitHub Copilot Instructions for Refactored Work Priorities (Continued) Mod

## Mod Overview and Purpose
**Mod Name:** Refactored Work Priorities (Continued)  
**Original Author:** Dingo  
**Mod Description:**  
Update of the Dingos mod for RimWorld. This mod grants you additional control over colonists, including some tweaks to their work priorities and schedules. Key features include:

- Injured animals will be fed by handlers instead of doctors.
- Removing roofs prioritized above building roofs.
- Custom repair threshold.
- Repair designator to force repairs on buildings above the repair threshold.
- Prioritize rottables and deterioratables.
- Set an item HP threshold to avoid prioritizing items with low HP.

## Key Features and Systems

### Features:
- **Custom Repair Threshold:** Allows players to set a repair threshold for buildings. Colonists will prioritize repairs on buildings above this threshold.
- **Repair Designator:** A new designator that allows players to force repairs on buildings above the repair threshold.
- **Prioritize Rottables and Deterioratables:** Colonists will prioritize hauling items like corn, meals, and other rottable and deterioratable items.
- **Injured Animals Feeding:** Handlers will feed injured animals instead of doctors.
- **Roof Removal Priority:** Prioritizes removing roofs above building roofs.

### Systems:
- **Options Menu:** A settings menu for mod customization.
- **Harmony Patching:** Used for modifying vanilla game behavior.
- **Custom Work Givers:** New work givers for handling custom behaviors (e.g., repairing buildings above a threshold).

## Coding Patterns and Conventions

### Naming Conventions:
- **Classes:** PascalCase (e.g., `WorkGiver_RepairCustom`)
- **Methods:** PascalCase (e.g., `HasJobOnThing`)
- **Fields:** camelCase (e.g., `repairThreshold`)
- **Constants:** ALL_CAPS (e.g., `MAX_HP_THRESHOLD`)

### File Structure:
- **Source Folder:** Contains C# source files.
- **Patches Folder:** Contains XML files for Harmony patches.
- **DefInjected Folder:** Contains XML files for key bindings and other definitions.

### Best Practices:
- **Code Comments:** Add comments to explain complex logic.
- **Unit Testing:** Write unit tests for critical functionality.
- **Consistent Formatting:** Use consistent indentation and formatting.

## XML Integration

### XML Files:
- **DesignationCategories.xml**: Defines new designation categories.
- **Jobs_Work.xml**: Defines custom job definitions.
- **ComplexJobs.xml**: Defines complex jobs.
- **WorkGivers.xml**: Defines custom work giver definitions.
- **KeyBindings.xml**: Defines key bindings for the mod.

### XML Conventions:
- **Indentation:** Use 4 spaces for indentation.
- **Attributes:** Use camelCase for attribute names.
- **Comments:** Use XML comments (`<!-- -->`) to explain complex configurations.

## Harmony Patching

### Harmony Patches:
- **Purpose:** Used to modify vanilla game behavior without modding the core game files.
- **Usage:** Create patches in the `Patches` folder and reference them in the mod's main assembly.

### Patching Conventions:
- **Patch Classes:** Use PascalCase for patch class names (e.g., `Patch_Harmony`).
- **Patch Methods:** Use PascalCase for patch method names (e.g., `Prefix` or `Postfix`).
- **Attributes:** Use `[HarmonyPatch]` attributes to specify the target method and patch type.

## Suggestions for Copilot

### General Suggestions:
- **Code Snippets:** Provide code snippets for common patterns (e.g., creating new work givers, handling designations).
- **XML Examples:** Provide XML examples for defining new job definitions and designation categories.
- **Harmony Patches:** Provide examples of creating and applying Harmony patches.

### Specific Requests:
- **Work Giver Examples:** Provide examples of creating new work givers with custom logic.
- **Designator Examples:** Provide examples of creating new designators with custom behavior.
- **Settings Menu Examples:** Provide examples of creating and integrating a settings menu for mod customization.

### Documentation:
- **Modding Guidelines:** Provide a guide for modding RimWorld, including best practices and common patterns.
- **API Documentation:** Provide documentation for the mod's API, including available methods and classes.

By following these guidelines and conventions, you can ensure that your contributions to the Refactored Work Priorities (Continued) mod are consistent, maintainable, and aligned with the existing codebase.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

