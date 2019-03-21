package com.eurekaservice.EurekaServiceProject;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@SpringBootApplication
@EnableEurekaServer
public class EurekaServiceProjectApplication {

	public static void main(String[] args) {
		SpringApplication.run(EurekaServiceProjectApplication.class, args);
	}

}
