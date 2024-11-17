#!/usr/bin/env python3

import os
import json
from config.args_parser import parse_args
from processing.complete_paths import complete_paths
from processing.create_state_dictionary import create_state_dictionary
from processing.create_next_states_dictionary import create_next_states_dictionary
from processing.process_include_configuration import process_include_configuration
from utils.file_utils import find_all_cs_files
from utils.class_utils import find_classes_implementing_interface, find_all_child_classes
from utils.include_directives import find_include_directives

DEFAULT_OUTPUT_DIRECTORY = 'IncludeConfig'
DEFAULT_INITIAL_STATE_NAME = 'InitialState'
DEFAULT_CONFIG_NAME = 'RelationsConfig'

def main():
    args = parse_args()

    root_dir = args.project
    out_dir = os.path.join(root_dir, args.output_dir)
    interface_name = 'IQueryObject'

    cs_files = []
    dal_dirs = [subdir for subdir, _, _ in os.walk(root_dir) if 'DAL' in os.path.basename(subdir)]
    for dal_dir in dal_dirs:
        cs_files.extend(find_all_cs_files(dal_dir))

    classes = find_classes_implementing_interface(cs_files, interface_name)

    if not classes:
        cs_files = find_all_cs_files(root_dir)
        classes = find_classes_implementing_interface(cs_files, interface_name)

    if not classes:
        print(f"No classes implementing {interface_name} found.")
        return

    if len(classes) > 1 and not args.classname:
        print(f"Multiple classes implementing {interface_name} found:")
        for cls, path in classes.items():
            print(f"{cls} in {path}")
        selected_class = input("Please specify the class to search for IncludeDirectives: ")
    else:
        selected_class = args.classname if args.classname else next(iter(classes))

    all_child_classes = find_all_child_classes(root_dir, selected_class)

    most_specific_classes = {cls: path for cls, path in all_child_classes.items() if cls not in all_child_classes.values()}

    results = []
    for cls, file_path in most_specific_classes.items():
        include_directives = find_include_directives(file_path)
        if include_directives:
            for file_path, entity_type, cleaned_code in include_directives:
                result = {
                    "Entity": entity_type,
                    "paths": cleaned_code
                }
                results.append(result)
        else:
            print(f"No IncludeDirectives found in {cls}.")

    if results:
        for result in results:
            entity_data = {
                "Entity": result["Entity"],
                "paths": result["paths"]
            }

            # empty IncludeDirectives specified in the code 
            if entity_data["paths"] == ['']:  
                continue

            completed_paths = complete_paths(entity_data)
            state_dictionary = create_state_dictionary(completed_paths, args.initial_state_name)
            next_states_dictionary = create_next_states_dictionary(state_dictionary, args.initial_state_name)
            process_include_configuration(next_states_dictionary, out_dir, args.config_name)


    else:
        print("No IncludeDirectives found.")

if __name__ == "__main__":
    main()