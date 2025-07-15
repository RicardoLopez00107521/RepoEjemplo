package com.example.demo.repositories;

import com.example.demo.domain.entities.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserRepository extends JpaRepository<User, Integer>{
    User findUserByUserId(Integer userId);
    User findUserByUserName(String userName);
}
