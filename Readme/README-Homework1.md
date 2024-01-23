# 實作功能
於本機端建立以 Nodejs + Nestjs 為主的後端開發環境

## 驗收方式
1. 使用 4000 port 作為後端 server port
2. 於開發環境中實作 (get) helloworld API，
3. 搭配 Ngrok 可讓人遠端於網頁直接輸入上述 ngrok_url/helloworld 後顯示 hello world
4. 將 source code 上傳至 github/gitlab，並需撰寫 readme 來說明如何建立(使用 Markdown 語法)

## 實作功能
作業實作項目描述

## 驗收方式
具體描述驗收條件

## 附註
補充說明


# 參考網址

- **.NET Core CLI：建立方案與專案**  
https://ithelp.ithome.com.tw/articles/10217801

- **Tutorials for getting started with .NET**  
https://learn.microsoft.com/en-us/dotnet/standard/get-started#tutorials-for-creating-apps

| Templates                                  | Short Name | Language         | Tags               |
|--------------------------------------------|------------|------------------|--------------------|
| Console Application                        | console    | [C#], F#, VB     | Common/Console     |
| Class Library                              | classlib   | [C#], F#, VB     | Common/Library     |
| Unit Test Project                          | mstest     | [C#], F#, VB     | Test/MSTest        |
| ASP.NET Core Web App (Model-View-Controller)| mvc        | [C#], F#         | Web/MVC            |
| ASP.NET Core Web API                       | webapi     | [C#], F#         | Web/WebAPI         |
| Solution File                              | sln        | Solution         |                    |
	


- **add project**  
dotnet new webapi --use-controllers -o homework1

cd homework1

dotnet new sln

dotnet sln add homework1.csproj

- **ngrok**  
https://dashboard.ngrok.com/get-started/setup/windows

ngrok config add-authtoken 7GwJsMHzoto7QkLkEpEUK_cJ4SKogbpjcRLqmkVQqW

ngrok http 4000
