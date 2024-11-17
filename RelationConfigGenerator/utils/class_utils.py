import re
import os
from collections import deque

def find_classes_implementing_interface(files, interface_name):
    """
    Find classes implementing a specific interface.

    Args:
        files (list): A list of file paths to search in.
        interface_name (str): The name of the interface to search for.

    Returns:
        dict: A dictionary where keys are class names and values are file paths.
    """
    classes = {}
    class_pattern = re.compile(r'(?:public\s+|protected\s+|private\s+)?(?:abstract\s+)?class\s+(\w+)(?:<.*?>)?\s*:\s*.*\b' + re.escape(interface_name) + r'\b')
    for file_path in files:
        with open(file_path, 'r', encoding='utf-8') as f:
            content = f.read()
            matches = class_pattern.findall(content)
            for match in matches:
                classes[match] = file_path
    return classes

def find_child_classes(root_dir, parent_class):
    """
    Find child classes of a specific parent class.

    Args:
        root_dir (str): The root directory to search in.
        parent_class (str): The name of the parent class.

    Returns:
        dict: A dictionary where keys are child class names and values are file paths.
    """
    child_classes = {}
    class_pattern = re.compile(r'class\s+(\w+)(?:<.*?>)?\s*:\s*.*\b' + re.escape(parent_class) + r'\b')
    for subdir, _, files in os.walk(root_dir):
        for file in files:
            if file.endswith(".cs"):
                file_path = os.path.join(subdir, file)
                with open(file_path, 'r', encoding='utf-8') as f:
                    content = f.read()
                    matches = class_pattern.findall(content)
                    for match in matches:
                        if match != parent_class:
                            child_classes[match] = file_path
    return child_classes

def find_all_child_classes(root_dir, parent_class):
    """
    Find all child classes of a specific parent class, including nested children.

    Args:
        root_dir (str): The root directory to search in.
        parent_class (str): The name of the parent class.

    Returns:
        dict: A dictionary where keys are child class names and values are file paths.
    """
    all_child_classes = {}
    queue = deque([parent_class])
    visited = set()
    while queue:
        current_class = queue.popleft()
        if current_class in visited:
            continue
        visited.add(current_class)
        child_classes = find_child_classes(root_dir, current_class)
        for child_class, file_path in child_classes.items():
            if child_class not in all_child_classes:
                all_child_classes[child_class] = file_path
                queue.append(child_class)
    return all_child_classes