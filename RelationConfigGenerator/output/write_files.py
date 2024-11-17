def write_class_file(initial_entity_name, class_def, class_interfaces, output_dir, config_name, namespace):
    """
    Write the class file for the given configuration.

    This function generates the class file for the given configuration name. It includes methods for adding and removing
    include paths, and integrates the necessary interfaces if provided.

    Args:
        initial_entity_name (str): The name of the initial entity.
        class_def (str): The class definition string.
        class_interfaces (set): A set of interfaces to be implemented by the class.

    Returns:
        None
    """
    include_code = """
        private readonly List<string> _includes = new List<string>(); // Stores the includes for related entities

        /// <summary>
        /// Gets the list of includes to be applied to the query.
        /// </summary>
        public virtual List<string> Includes => _includes;

        /// <summary>
        /// Adds an include path to the current query object.
        /// </summary>
        /// <param name="include">The path of the include to be added.</param>
        protected void AddInclude(string include)
        {
            if (!string.IsNullOrWhiteSpace(include) && !_includes.Contains(include))
            {
                _includes.Add(include);
            }
        }

        /// <summary>
        /// Removes an include path from the current query object.
        /// </summary>
        /// <param name="include">The path of the include to be removed.</param>
        protected void RemoveInclude(string include)
        {
            if (_includes.Contains(include))
            {
                _includes.Remove(include);
            }
        }
    """
    if class_interfaces:
        class_def = class_def.replace(f"public class {initial_entity_name}{config_name} : ", f"public class {initial_entity_name}{config_name} : {', '.join(class_interfaces)}\n{{\n{include_code}\n")
    else:
        class_def = class_def.replace(f"public class {initial_entity_name}{config_name} : ", f"public class {initial_entity_name}{config_name}\n{{\n{include_code}\n")
    class_def += "    }\n}\n"
    with open(f"{output_dir}/{initial_entity_name}/{config_name}.cs", 'w') as file:
        file.write(class_def)

def write_interface_files(interfaces, output_dir, initial_entity_name, namespace):
    """
    Write the interface files for the given interfaces.

    This function generates the interface files for the given interfaces. Each interface includes the methods
    specified in the interfaces dictionary.

    Args:
        interfaces (dict): A dictionary where the keys are interface names and the values are sets of method signatures.

    Returns:
        None
    """
    for interface_name, methods in interfaces.items():
        interface_def = f"namespace {namespace}.Interfaces\n{{\n    public interface {interface_name}\n    {{\n"
        for method in set(methods):
            interface_def += f"        {method}\n"
        interface_def += "    }\n}\n"
        with open(f"{output_dir}/{initial_entity_name}/Interfaces/{interface_name}.cs", 'w') as file:
            file.write(interface_def)