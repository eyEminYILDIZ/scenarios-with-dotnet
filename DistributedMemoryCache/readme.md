# Distributed Memory Cache scenario

This project demonstrates distributed cache layer.

First call miss cache, then set automatically. Subsequent calls will hit cache in the TTL time.

## Attention

Make sure the Redis up and running also setup redis connection string in appsettings.json file.