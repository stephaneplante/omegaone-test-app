FROM mcr.microsoft.com/dotnet/sdk:5.0

RUN apt-get update && \
    apt-get install -y procps

RUN groupadd -g 1000 -r omegaone && \
    useradd -u 1000 -r -g omegaone -m -s $(which bash) omegaone

RUN mkdir /app

COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]

RUN runuser -l omegaone -c "dotnet tool install --global dotnet-outdated-tool"
ENV PATH "$PATH:/home/omegaone/.dotnet/tools"
