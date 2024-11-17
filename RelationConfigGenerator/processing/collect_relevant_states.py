def collect_relevant_states(transitions):
    """
    Collect relevant states from a list of transitions.

    This function processes a list of transition dictionaries to identify and collect all relevant states.
    A state is considered relevant if it is either a current state in any transition or a next state referenced
    by any transition.

    Args:
        transitions (list): A list of transition dictionaries. Each dictionary should have the keys 'current_state'
                            and 'next_states'. 'current_state' is a string representing the current state, and
                            'next_states' is a list of strings representing the possible next states.

    Returns:
        set: A set of all relevant states, which includes both current states and next states.
    """
    relevant_states = set()
    referenced_states = set()
    
    for transition in transitions:
        current_state = transition['current_state']
        next_states = transition['next_states']
        
        if next_states:
            relevant_states.add(current_state)
            referenced_states.update(next_states)
    
    return relevant_states.union(referenced_states)