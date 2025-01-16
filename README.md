# DALL·E Image Generator with C# and OpenAI API

## 📖 Project Overview
This project is a **C# console application** that generates AI-powered images using **OpenAI's DALL·E API**. By entering a text prompt, the application will create a high-quality image based on your description and save it to your local machine.

---

## 🚀 Features
- **Text-to-Image Generation**: Convert any text prompt into a stunning AI-generated image.
- **Secure API Key Handling**: Uses environment variables to protect sensitive API keys.
- **Automated Image Download**: Saves generated images directly to the project's `bin` folder.
- **Beginner-Friendly Code**: Well-documented and easy to understand for new developers.

---

## 🛠️ Technologies Used
- **C# (.NET 6/7)**  
- **OpenAI DALL·E API**  
- **HttpClient** for REST API calls  
- **Newtonsoft.Json** for JSON handling  

---

## 📦 Installation & Setup

### 1. **Clone the Repository**
```bash
git clone https://github.com/sahithkumar1999/OpenAi_Applications.git
cd OpenAi_Applications/src/Applications
```

### 2. **Install Dependencies**
Ensure you have the .NET SDK installed. Install required packages:
```bash
dotnet add package Newtonsoft.Json
```

### 3. **Get OpenAI API Key**
- Sign up at [OpenAI](https://platform.openai.com/)
- Navigate to the API section and generate your API key.

### 4. **Set Environment Variable**
**Windows (CMD):**
```cmd
setx OPENAI_API_KEY "your-api-key-here"
```

**Linux/macOS (Bash):**
```bash
export OPENAI_API_KEY="your-api-key-here"
```

### 5. **Run the Application**
```bash
dotnet run
```

---

## 💻 Usage
1. **Enter a Description** when prompted (e.g., *"A futuristic city at sunset"*).
2. **View the Console Output** to see the generated image URL.
3. **Check the `bin` Folder** for the downloaded image (`generated_image.png`).

---

## 📂 Project Structure
```
├── Program.cs               // Main application logic
├── README.md                // Project documentation
├── bin/                     // Compiled binaries and downloaded images
├── obj/                     // Build objects
└── dalle-image-generator.sln// Project solution file
```

---

## 🔒 Security Notice
- **Never hardcode your API keys** in the source code.
- Always use **environment variables** to manage sensitive credentials.

---

## 🚀 Future Enhancements
- 🎨 Allow custom image sizes and styles.
- 🖼️ Support generating multiple images at once.
- 🌐 Build a web interface for easier interaction.
- 🛠️ Improve error handling and user feedback.

---

## 🤝 Contributing
Contributions are welcome! 🙌

1. Fork the repository
2. Create a feature branch (`git checkout -b feature-name`)
3. Commit your changes (`git commit -m 'Add feature'`)
4. Push to the branch (`git push origin feature-name`)
5. Open a Pull Request

---

## 📄 License
This project is licensed under the [Apache-2.0](LICENSE).

---

**Happy Coding! 🚀**
