# 實作功能
於本機安裝 docker 與 docker-compose，並將開發環境透過 docker 部署

## 驗收方式
1. 撰寫 dockerfile
2. 使用 docker-compose 啟動開發環境

## 附註
補充說明

- **發布為docker專案**
dotnet publish --os linux --arch x64 /t:PublishContainer -c Release

- **build image**
docker build -t homework -f ./Homework/Dockerfile .

- **顯示目前有哪些image**
docker image

- **docker run image 指定 container 名稱**
docker run --name=homework -d -p 4000:8080 -it homework

- docker compose啟動
docker-compose -f docker-compose.yml up -d