from .collect_relevant_states import collect_relevant_states
from .process_transitions import process_transitions
from utils.directory_operations import create_directories
from output.write_files import write_class_file, write_interface_files

def process_include_configuration(next_states_dictionary, output_dir, config_name):
    """
    Process the include configuration based on the next states dictionary.

    This function creates necessary directories, collects relevant states, processes transitions, and writes
    class and interface files for the include configuration.

    Args:
        next_states_dictionary (dict): A dictionary containing the next states information. It should have the following keys:
            - "initial_entity" (str): The name of the initial entity.
            - "transitions" (list): A list of transition dictionaries. Each dictionary should have the keys
                                    'current_state', 'path', and 'next_states'.

    Returns:
        None
    """

    # Extract the initial entity name and transitions from the next states dictionary
    initial_entity_name = next_states_dictionary['initial_entity']
    transitions = next_states_dictionary['transitions']

    # Create necessary directories
    create_directories([f'{output_dir}/{initial_entity_name}', f'{output_dir}/{initial_entity_name}/Interfaces'])
    
    # Initialize an empty dictionary to store interfaces
    interfaces = {}
    
    # Initialize the class definition string
    sanitized_output_dir = output_dir.replace('/', '.').lstrip('.')

    namespace = f"{sanitized_output_dir}.{config_name}.{initial_entity_name}"
    class_def = f"using {namespace}.Interfaces;\n\nnamespace {namespace}\n{{\n    public class {initial_entity_name}{config_name} : "
    
    # Collect all relevant states from the transitions
    all_relevant_states = collect_relevant_states(transitions)
    
    # Process transitions to generate class methods and interfaces
    class_methods, class_interfaces = process_transitions(transitions, all_relevant_states, interfaces)
    
    # Append the class methods to the class definition
    class_def += class_methods
    
    # Write the class file
    write_class_file(initial_entity_name, class_def, class_interfaces, output_dir, config_name, namespace)

    # Write the interface files
    write_interface_files(interfaces, output_dir, initial_entity_name, namespace)