# base image
FROM node:10.8

# set working directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH

# install and cache app dependencies
COPY package.json /usr/src/app/package.json
RUN npm install -g npm@latest && npm install -g @angular/cli
RUN npm install

# add app
COPY . /usr/src/app

# start app
CMD ng serve --host 0.0.0.0
