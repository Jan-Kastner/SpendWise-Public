def process_path_part(path_part):
    """
    Process a part of a path to extract lowercase letters from uppercase letters.

    This function takes a string representing a part of a path and extracts lowercase letters from uppercase letters.
    It then capitalizes the result if it is not empty.

    Args:
        path_part (str): A string representing a part of a path.

    Returns:
        str: A processed string with lowercase letters extracted from uppercase letters and capitalized if not empty.
    """
    result = ''.join(char.lower() for char in path_part if char.isupper())
    return result.capitalize() if result else ""

def create_state_dictionary(entity_data, initial_state_name):
    """
    Create a state dictionary for an entity based on its paths.

    This function processes an entity's paths to generate a dictionary that maps each path to a current state name.
    It handles different levels of paths and constructs appropriate state names based on the path structure.

    Args:
        entity_data (dict): A dictionary containing the entity's data. It should have the following keys:
            - "Entity" (str): The name of the entity.
            - "paths" (list): A list of strings representing the paths.

    Returns:
        dict: A dictionary with the initial entity name and a list of transitions. Each transition maps a current state
              to its corresponding path. The dictionary has the following structure:
              {
                  "initial_entity": <entity_name>,
                  "transitions": [
                      {
                          "current_state": <current_state_name>,
                          "path": <path>
                      },
                      ...
                  ]
              }
    """
    entity_name = entity_data['Entity']
    state_structure = {
        "initial_entity": entity_name,
        "transitions": []
    }

    for path in entity_data['paths']:
        if len(path) == 0:
            current_state_name = f"{entity_name}{initial_state_name}"
        elif len(path.split('.')) == 1:
            current_state_name = f"Include{path}"
        else:
            parts = path.split('.')
            current_state_name = "Then" + ''.join(process_path_part(s) for s in parts[:-1]) + "Include" + parts[-1]
        
        state_structure["transitions"].append({
            "current_state": current_state_name,
            "path": path
        })

    return state_structure