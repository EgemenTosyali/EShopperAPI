docker compose up --force-recreate --build -d && docker rmi $(docker images -f "dangling=true" -q)