import re

def find_include_directives(file_path):
    """
    Find include directives in a given file.

    Args:
        file_path (str): The path to the file to search in.

    Returns:
        list: A list of tuples containing file path, entity type, and cleaned code.
    """
    include_directives = []
    pattern = re.compile(r'public\s*(?:virtual|override)\s*ICollection\s*<\s*Func\s*<\s*(\w+)\s*,\s*object\s*>\s*>\s*IncludeDirectives\s*{\s*get\s*;\s*}\s*=\s*new\s*List\s*<\s*Func\s*<\s*\w+\s*,\s*object\s*>\s*>\s*{([^}]*)\s*};', re.MULTILINE | re.DOTALL)

    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()
        matches = pattern.findall(content)
        if matches:
            for match in matches:
                entity_type = match[0]
                code_block = match[1]
                cleaned_code = clean_code_block(code_block)
                include_directives.append((file_path, entity_type, cleaned_code))

    return include_directives

def clean_code_block(code_block):
    """
    Clean a code block by removing unnecessary characters.

    Args:
        code_block (str): The code block to clean.

    Returns:
        list: A list of cleaned code strings.
    """
    cleaned_code = re.sub(r'\s+', '', code_block)
    cleaned_code = re.sub(r'entity=>entity\.', '', cleaned_code)
    cleaned_code = re.sub(r'Select\(\w*=>\w*\.', '', cleaned_code)
    cleaned_code = re.sub(r'[(){}<>]', '', cleaned_code)
    cleaned_code = re.sub(r';', '', cleaned_code)
    cleaned_code = re.sub(r'!', '', cleaned_code)
    return cleaned_code.split(',')