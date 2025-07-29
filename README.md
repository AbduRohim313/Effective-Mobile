# 📅 Рекламные Площадки — ASP.NET Core Web API

## 📄 Описание

REST API для загрузки и поиска рекламных площадок по регионам.
Сервис работает с локациями в формате `/ru/...` и определяет вложенность площадок по префиксу.

## 🚀 Как запустить проект

### 1. Клонируй репозиторий:

```bash
git clone https://github.com/your-username/your-repository.git
cd your-repository
```

### 2. Скачай .NET SDK и установи

Скачать SDK:
[.NET SDK 8.0.412 (Windows x64)](https://builds.dotnet.microsoft.com/dotnet/Sdk/8.0.412/dotnet-sdk-8.0.412-win-x64.exe)

### 3. Построй и запусти приложение:

```bash
dotnet restore
dotnet run
```

### 4. Адреса по умолчанию:

```json
"profiles": {
  "http": {
    "applicationUrl": "http://localhost:5203"
  },
  "https": {
    "applicationUrl": "https://localhost:7157;http://localhost:5203"
  }
}
```

---

## 📦 Примеры API-запросов

### ↻ Загрузка рекламных площадок

**POST** `/load`
**Content-Type:** `multipart/form-data`
**Параметр:** `file` — текстовый файл (расширение `.txt` или без расширения)

---

### 🔍 Поиск рекламных площадок

**GET** `/reklama?location=/ru/svrd/revda`

---

## 💡 Структура проекта

* `Controllers` — веб-контроллеры (API)
* `Services` — бизнес-логика
* `Interfaces` — контракты (IService, IRepository)
* `Repository` — in-memory хранилище
* `Dto` — модели DTO

---

## 👤 Автор

АбдуРохим | AbduRohim313

