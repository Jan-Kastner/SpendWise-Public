import json

def create_next_states_dictionary(entity_data, initial_state_name):
    """
    Create a dictionary of next states for each transition.

    This function processes an entity's transition data to generate a dictionary that maps each current state
    to its possible next states based on the provided paths. It also handles nested paths and ensures that
    intermediate states are considered.

    Args:
        entity_data (dict): A dictionary containing the entity's transition data. It should have the following keys:
            - "initial_entity" (str): The name of the initial entity.
            - "transitions" (list): A list of transition dictionaries. Each dictionary should have the keys
                                    'current_state' and 'path'.

    Returns:
        dict: A dictionary with the initial entity name and a list of transitions. Each transition maps a current state
              to its possible next states. The dictionary has the following structure:
              {
                  "initial_entity": <entity_name>,
                  "transitions": [
                      {
                          "current_state": <current_state>,
                          "path": <path>,
                          "next_states": [<next_state1>, <next_state2>, ...]
                      },
                      ...
                  ]
              }
    """
    if "transitions" not in entity_data:
        raise KeyError("Missing 'transitions' in entity_data")

    transitions = entity_data["transitions"]
    entity_name = entity_data["initial_entity"]

    next_states_dict = {
        "initial_entity": entity_name,
        "transitions": []
    }

    # Create a mapping of paths to current states
    states_by_path = {transition["path"]: transition["current_state"] for transition in transitions}

    for transition in transitions:
        current_state = transition["current_state"]
        path = transition["path"]
        path_parts = path.split('.')
        path_length = len(path_parts)

        next_states = set()

        if path_length == 0:
            # If the path is empty, consider all top-level states as next states
            next_states.update(s for p, s in states_by_path.items() if len(p.split('.')) == 1)
        elif path_length >= 1:
            first_part = path_parts[0]
            # Consider all top-level states except the first part of the current path
            next_states.update(s for p, s in states_by_path.items() if len(p.split('.')) == 1 and p != first_part)
            # Consider states at the same level as the current path
            for candidate_path, candidate_state in states_by_path.items():
                candidate_parts = candidate_path.split('.')
                if len(candidate_parts) == path_length and candidate_parts[:-1] == path_parts[:-1] and candidate_path != path:
                    next_states.add(candidate_state)
            # Consider states at the next level of the current path
            next_length = path_length + 1
            for candidate_path, candidate_state in states_by_path.items():
                if len(candidate_path.split('.')) == next_length and candidate_path.startswith(path + '.'):
                    next_states.add(candidate_state)

        # Remove specific state if necessary
        next_states.discard(f"{entity_name}{initial_state_name}")

        next_states_dict["transitions"].append({
            "current_state": current_state,
            "path": path,
            "next_states": list(next_states)
        })

    return next_states_dict