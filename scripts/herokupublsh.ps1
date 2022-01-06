cd ./src
heroku container:push -a omegaone-test-app web
heroku container:release -a omegaone-test-app web
cd ..
