# VOLUME POSTGRES - MOUNT TO EXISTING VOLUME named dp-user-management
docker run --name dp-vol --env-file ./.env.postgres -v dp-user-management:/var/lib/postgresql -p 5432:5432 -d postgres:latest