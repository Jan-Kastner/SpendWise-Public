import argparse

def parse_args():
    """
    Parse command-line arguments.

    Returns:
        argparse.Namespace: Parsed command-line arguments.
    """
    parser = argparse.ArgumentParser(description="Find IncludeDirectives in a project and process configuration files.")
    parser.add_argument('--project', required=True, help="The project directory to search in.")
    parser.add_argument('--classname', help="The specific class to search for IncludeDirectives if multiple classes implement the interface.")
    parser.add_argument('-o', '--output-dir', type=str, default='IncludeConfig', help='Directory to save the output files. Default: %(default)s')
    parser.add_argument('--initial-state-name', type=str, default='InitialState', help='Name part for initial state. Default: %(default)s')
    parser.add_argument('--config-name', type=str, default='RelationsConfig', help='Name part for configuration files. Default: %(default)s')
    return parser.parse_args()