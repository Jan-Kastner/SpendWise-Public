import os

def create_directories(directories):
    """
    Create directories if they do not exist.

    This function takes a list of directory paths and creates each directory if it does not already exist.
    It uses the os.makedirs function to create the directories, ensuring that any intermediate-level directories
    are also created.

    Args:
        directories (list): A list of strings, where each string is a directory path to be created.

    Returns:
        None
    """
    for directory in directories:
        if not os.path.exists(directory):
            os.makedirs(directory)