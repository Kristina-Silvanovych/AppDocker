#!/bin/bash

# �������� ������
IMAGE_NAME="appdocker:dev"

# �������� ����������
CONTAINER_NAME="AppDocker"

# ���� �����:���� ����������
PORT_MAPPING="8080:8080"

# ������� ����� Docker �� �������� ��������, ��� ������ ���������� Dockerfile
docker build -t $IMAGE_NAME .

# ��������� ��������� �� ���������� ������
docker run -d --name $CONTAINER_NAME -p $PORT_MAPPING $IMAGE_NAME
echo "Container ${CONTAINER_NAME} launched successfully."