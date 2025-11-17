# ReadmeGen

## Overview

ReadmeGen is a .NET web application designed to help you automatically generate README files for your projects. You can provide a GitHub repository link or upload a project folder, and the app will analyze the project and create a suitable README for you.

## Features

- Accepts a GitHub project link or uploaded project folder
- Uses AI to analyze project structure and content
- Returns a generated README based on the provided project
- REST API endpoints for integration and automation

## How It Works

1. Send a POST request to the API with a GitHub link or project folder.
2. The app fetches and analyzes the project data.
3. It uses AI to generate a README file tailored to your project.

## Status

- The API is set up and can receive requests.
- AI integration for generating responses is working.
- Project link and folder upload features are planned.

## Getting Started

1. Clone the repository.
2. Set your API key in the environment variables.
3. Run the app with `dotnet run`.
4. Use the `/input/generate` endpoint to test AI responses.

## Future Plans

- Improve project analysis for more detailed READMEs.
- Add support for more project types and languages.
- Enhance the user interface and documentation.

---
