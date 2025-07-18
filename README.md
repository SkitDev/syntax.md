# syntax.md ✍️💥

a stupidly fast markdown editor & previewer that looks cool and just works™  
powered by html/css/js + webview2 + vibes + spite

---

## ✨ Features

- ✅ live markdown preview
- ✅ highlight.js for code blocks
- ✅ dark mode default
- ✅ saves as `.md`
- ✅ portable & clean
- ✅ zero dependencies after first launch
- ✅ pulls the html+js from a GitHub archive automatically
- ✅ webview2 powered
- ✅ no telemetry, no BS, just vibes

---

## 🚀 Usage

```sh
Download & run `syntaxmd.exe`
```

On first launch, it will:

1. download the UI archive from GitHub
2. unzip to `%LocalAppData%\syntaxmd\`
3. open `index.html` in a WebView2 window

after that, it just loads from that local dir. no internet required.

---

## 📦 Build Instructions (Optional)

1. open the project in Visual Studio 2022+
2. make sure you're on **.NET 6 or 7**
3. install the **WebView2 SDK**
4. build `Release` configuration
5. run or publish (`right-click project > Publish` if you want)

---

## 🗃️ Structure

```txt
syntaxmd/
├── index.html
├── script.js
├── styles.css
├── highlight/
│   └── highlight.min.js
└── syntaxmd.exe (WinForms + WebView2)
```

---

## 💾 Save Behavior

- click the `💾 Save` button
- it downloads your markdown editor contents as a `.md` file

---

## 🧃 Notes

- you need [WebView2 Runtime](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)
- built with 💔 and copium
- tested on Windows 10/11

---

## 🧛 credits

- made by [SkitDev](https://github.com/SkitDev)
- UI powered by markdown, highlight.js, and black magic

---

## 📜 license

MIT. idc what u do with it. fork it, sell it, tattoo it on your dog.
