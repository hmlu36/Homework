# 實作功能
於開發環境中架設可用來說明 API 規格的說明文件

## 驗收方式
1. 於 web browser 上輸入 ip:port/doc 後可出現 swagger 文件
2. 文件內容須包含 header/body/param/response
3. 做一個簡易的CRUD功能(新增/刪除/修改/查詢)
4. 撰寫單元測試功能(UnitTest)，測試CRUD功能是否如預期  


## 附註
1. 需寫一個Service，透過Dependency Injection注入Service完成CRUD的功能
2. 因為尚未連結資料庫，資料暫存在記憶體中
3. 檢驗新增(Create)完資料後，列表(GetAll)要可以查詢

[swagger註解沒出現的解法](https://stackoverflow.com/questions/65927107/xml-comments-are-not-shown-in-swagger-documentation-is-this-bug-in-swagger)
[swagger註解寫法參考](https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio)
[.NET Core 和 .NET Standard 的單元測試最佳做法](https://learn.microsoft.com/zh-tw/dotnet/core/testing/unit-testing-best-practices)  
