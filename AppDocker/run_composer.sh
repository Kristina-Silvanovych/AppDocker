#!/bin/bash

# Назва Docker Compose файла
COMPOSE_FILE="docker-compose.yaml"

# Перевірити наявність Docker Compose
if ! [ -x "$(command -v docker-compose)" ]; then
  echo 'Error: docker-compose is not installed.' >&2
  exit 1
fi

# Запуск Docker Compose проекту
docker-compose -p appdocker -f $COMPOSE_FILE up -d --build
echo "Docker Compose runned successfully."
