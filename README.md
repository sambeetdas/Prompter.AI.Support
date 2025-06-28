**What is Prompter.AI ?**

Prompter.AI is a dotnet library designed to simplify the development of applications using text-to-text generation large language models (LLMs). Prompter can integrate with various data sources, allowing applications to pull in and process information dynamically.

Prompter.AI supports inference with LLMs
- Azure Open AI
- HuggingFace (Llama, Mistral)
- Gemini

Prompter.AI supports inference type as source
- Microsoft SQL
- In-Memory JSON
- API
- My SQL (In-Progress)
- Oracle DB (In-Progress)
- PostGreSQL (In-Progress)

**What is Prompter.AI.Support ?**

It is a developer guide to implement solutions with **Prompt.AI**

Steps:
1. Install the nuget for Prompt.AI (**dotnet add package Prompter.AI**)
   
   ![image](https://github.com/user-attachments/assets/0c4f37ef-9cda-462d-bb8c-f5f9af3444a4)


2. Set the configs and define the scope.
   
   ![image](https://github.com/user-attachments/assets/cc525a20-e6fd-42ed-88d3-7f46969a1702)


3. Build APIs to get response for the user asked question. The API should interact with the method **ProcessQuestionWithDataAsync(requestLLM)** for inference.
   
![image](https://github.com/user-attachments/assets/cd68eb55-de3f-4859-83bf-c772c94e1423)
![image](https://github.com/user-attachments/assets/9f6315d5-0f53-4558-849c-eb1593961edf)

4. It is also used to generate Query for the question asked by using the method **ProcessQuestionWithQueryAsync(requestLLM)**.

   ![image](https://github.com/user-attachments/assets/4a4fd5f0-fc6d-42ff-a800-19a2a2d6e4d1)


**This repository also includes an HTML page that integrates with the above APIs to build chat-based applications.**

![image](https://github.com/user-attachments/assets/547f3012-38f2-40a7-9cff-a23c87dc33cf)




*Note: Please tune the user prompt if you come across any error or the result is not accurate 
