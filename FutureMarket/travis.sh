#!/bin/bash

set -e

if [[ -n "$CF_PASSWORD" ]]; then
  wget -q -O - https://packages.cloudfoundry.org/debian/cli.cloudfoundry.org.key | sudo apt-key add -
  echo "deb https://packages.cloudfoundry.org/debian stable main" | sudo tee /etc/apt/sources.list.d/cloudfoundry-cli.list
  sudo apt-get update
  sudo apt-get install cf-cli
  CF_APP=banking-nest-lmac
  CF_USERNAME=u201819681@upc.edu.pe
  CF_ORGANIZATION=u201819681@upc.edu.pe
  CF_SPACE=dev
  echo $CF_APP
  echo $CF_USERNAME
  echo $CF_PASSWORD
  echo $CF_ORGANIZATION
  echo $CF_SPACE
  cf api https://api.us-south.cf.cloud.ibm.com
  cf login -u $CF_USERNAME -p $CF_PASSWORD -o $CF_ORGANIZATION -s $CF_SPACE
  cf push --no-start
  cf start $CF_APP
else
  echo "Skip deploy to IBM Cloud Foundry because CF_PASSWORD is empty"
  exit 1
fi