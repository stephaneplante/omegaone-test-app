FROM mcr.microsoft.com/dotnet/sdk:5.0

RUN useradd -m -s $(which bash) omegaone

RUN mkdir /app && chown omegaone:omegaone /app

USER omegaone