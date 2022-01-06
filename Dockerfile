FROM mcr.microsoft.com/dotnet/core/sdk:3.1

RUN useradd -m -s $(which bash) omegaone

RUN mkdir /app && chown omegaone:omegaone /app

USER omegaone