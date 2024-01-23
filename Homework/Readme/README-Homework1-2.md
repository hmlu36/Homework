# 實作功能

**.Nest.js** 
於 Nestjs 開發環境中實現所有的 lifecycle hook，並解釋這些 hook 使用時機

---

**.Net Core**  
了解Service生命週期 (Application Lifetime)
並熟悉 DI 相依注入 (Dependency Injection) 有哪幾種，以及使用時機  
.Net Core的Middleware是甚麼?
實作一個登入頁後端驗證的功能，前端傳送帳號、密碼欄位
透過Middleware記錄RequestUrl和RequestBody寫入log檔(檔名: debug-yyyy-MM-dd.txt)

格式範例:
```C# 
$"{DateTime.Now} [Debug] Path: {context.Request.Path}. RequestBody: {requestBody}"
```
輸出範例

```
01/23/2024 11:33:33 [Debug] Path: /api/Login/LoginMember. RequestBody: {
  "userName": "joshua",
  "password": "test123!"
}
```
