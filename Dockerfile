FROM ubuntu:24.04

ENV DEBIAN_FRONTEND=noninteractive \
    DISPLAY=:0 \
    LANG=en_US.UTF-8 \
    LANGUAGE=en_US.UTF-8 \
    LC_ALL=en_US.UTF-8

# Base deps + X stack + Chrome runtime libs (Noble names)
RUN apt-get update && apt-get install -y \
    ca-certificates curl wget gnupg unzip supervisor \
    xvfb x11vnc novnc websockify xauth dbus x11-utils \
    fonts-liberation fonts-noto-color-emoji \
    libayatana-appindicator3-1 libasound2t64 libatk-bridge2.0-0 \
    libnss3 libxss1 libx11-xcb1 libgbm1 \
    libxcomposite1 libxdamage1 libxrandr2 libgtk-3-0 \
    libxshmfence1 libdrm2 libxkbcommon0 libu2f-udev xdg-utils libvulkan1 \
 && rm -rf /var/lib/apt/lists/*

# Google Chrome via keyring (apt-key is removed in Noble)
RUN mkdir -p /etc/apt/keyrings \
 && curl -fsSL https://dl.google.com/linux/linux_signing_key.pub \
  | gpg --dearmor -o /etc/apt/keyrings/google-linux.gpg \
 && echo "deb [arch=amd64 signed-by=/etc/apt/keyrings/google-linux.gpg] http://dl.google.com/linux/chrome/deb/ stable main" \
  > /etc/apt/sources.list.d/google-chrome.list \
 && apt-get update && apt-get install -y google-chrome-stable \
 && rm -rf /var/lib/apt/lists/*

# Non-root user for Chrome + data dir
RUN useradd -m -s /bin/bash chrome-user \
 && mkdir -p /home/chrome-user/chrome-data /tmp/runtime-chrome-user \
 && chown -R chrome-user:chrome-user /home/chrome-user /tmp/runtime-chrome-user

# Wrapper that waits for X and launches Chrome exactly like manual start
COPY run-chrome.sh /usr/local/bin/run-chrome.sh
RUN chmod +x /usr/local/bin/run-chrome.sh

# Supervisor config
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf

EXPOSE 5900 9090 9222

CMD ["/usr/bin/supervisord","-c","/etc/supervisor/conf.d/supervisord.conf"]
