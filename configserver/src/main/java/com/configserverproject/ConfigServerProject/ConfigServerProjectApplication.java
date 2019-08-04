package com.configserverproject.ConfigServerProject;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.config.server.EnableConfigServer;

@SpringBootApplication
@EnableConfigServer
public class ConfigServerProjectApplication {

	public static void main(String[] args) {
		SpringApplication.run(ConfigServerProjectApplication.class, args);
	}

}
