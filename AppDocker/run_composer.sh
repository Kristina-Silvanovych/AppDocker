#!/bin/bash

# ����� Docker Compose �����
COMPOSE_FILE="docker-compose.yaml"

# ��������� �������� Docker Compose
if ! [ -x "$(command -v docker-compose)" ]; then
  echo 'Error: docker-compose is not installed.' >&2
  exit 1
fi

# ������ Docker Compose �������
docker-compose -p appdocker -f $COMPOSE_FILE up -d --build
echo "Docker Compose runned successfully."
