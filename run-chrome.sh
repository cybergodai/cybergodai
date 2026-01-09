#!/usr/bin/env bash
set -euo pipefail

# Mirror your manual environment
export DISPLAY="${DISPLAY:-:0}"
export HOME="/home/chrome-user"
export XDG_RUNTIME_DIR="${XDG_RUNTIME_DIR:-/tmp/runtime-chrome-user}"
mkdir -p "$XDG_RUNTIME_DIR"
chown chrome-user:chrome-user "$XDG_RUNTIME_DIR"
chmod 700 "$XDG_RUNTIME_DIR"

echo "[wait-for-x] Checking X server on $DISPLAY ..."
for i in {1..40}; do
  if xdpyinfo -display "$DISPLAY" >/dev/null 2>&1; then
    echo "[wait-for-x] X is ready after $i s."
    break
  fi
  echo "[wait-for-x] ($i) not ready yet; sleeping 1s..."
  sleep 1
done

# A small extra buffer so x11vnc has attached as well
sleep 3

exec /usr/bin/google-chrome-stable \
  --no-sandbox \
  --disable-gpu \
  --disable-dev-shm-usage \
  --disable-software-rasterizer \
  --disable-features=VizDisplayCompositor \
  --no-first-run \
  --start-maximized \
  --user-data-dir="$HOME/chrome-data" \
  --remote-debugging-address=0.0.0.0 \
  --remote-debugging-port=9222 \
  https://www.google.com
