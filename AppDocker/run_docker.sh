#!/bin/bash

# Название образа
IMAGE_NAME="appdocker:dev"

# Название контейнера
CONTAINER_NAME="AppDocker"

# Порт хоста:порт контейнера
PORT_MAPPING="8080:8080"

# Собрать образ Docker из текущего каталога, где должен находиться Dockerfile
docker build -t $IMAGE_NAME .

# Запустить контейнер из собранного образа
docker run -d --name $CONTAINER_NAME -p $PORT_MAPPING $IMAGE_NAME
echo "Container ${CONTAINER_NAME} launched successfully."