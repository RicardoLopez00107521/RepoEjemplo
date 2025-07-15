package com.example.demo.services;

import com.example.demo.domain.dtos.GetUserDTO;
import com.example.demo.domain.dtos.NewUserDTO;
import com.example.demo.domain.entities.User;

import java.util.List;

public interface UserService {
    User findUserById(Integer userId);
    User findUserByUserName(String userName);

    void addUser(NewUserDTO newUserDTO);
    GetUserDTO userInfo(User user);
    List<GetUserDTO> findAllUser();
}
