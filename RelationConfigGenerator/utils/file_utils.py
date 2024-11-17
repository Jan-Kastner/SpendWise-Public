import os

def find_all_cs_files(root_dir):
    """
    Find all .cs files in the given directory.

    Args:
        root_dir (str): The root directory to search in.

    Returns:
        list: A list of paths to .cs files.
    """
    cs_files = []
    for subdir, _, files in os.walk(root_dir):
        for file in files:
            if file.endswith(".cs"):
                cs_files.append(os.path.join(subdir, file))
    return cs_files