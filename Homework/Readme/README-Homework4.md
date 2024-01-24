# 實作功能
於本機安裝 docker 與 docker-compose，並將開發環境透過 docker 部署

## 驗收方式
1. 撰寫 dockerfile
2. 使用 docker-compose 啟動開發環境

## 附註
補充說明


- **build image**
docker build -t di-docker-version -f Dockerfile .

- **顯示目前有哪些image**
docker image

- **docker run image 指定 container 名稱**
docker run --name=di-docker-version -d -p 4000:8080 -it di-docker-version 