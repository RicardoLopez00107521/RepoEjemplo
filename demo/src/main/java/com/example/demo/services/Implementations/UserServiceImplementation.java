package com.example.demo.services.Implementations;

import com.example.demo.domain.dtos.GetUserDTO;
import com.example.demo.domain.dtos.NewUserDTO;
import com.example.demo.domain.entities.User;
import com.example.demo.repositories.UserRepository;
import com.example.demo.services.UserService;
import jakarta.transaction.Transactional;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Slf4j
@Service
public class UserServiceImplementation implements UserService {

    private final UserRepository hola;

    public UserServiceImplementation(UserRepository userRepository) {
        this.hola = userRepository;
    }

    @Override
    public User findUserById(Integer userId) {
        return hola.findUserByUserId(userId);
    }

    @Override
    public User findUserByUserName(String userName) {
        return hola.findUserByUserName(userName);
    }

    @Override
    @Transactional
    public void addUser(NewUserDTO newUserDTO) {
        User newUser = new User();

        newUser.setUserName(newUserDTO.getUserName());
        newUser.setPassword(newUserDTO.getPassword());

        hola.save(newUser);
    }

    @Override
    public GetUserDTO userInfo(User user) {
        GetUserDTO getUserDTO = new GetUserDTO();

        getUserDTO.setUserName(user.getUserName());

        return getUserDTO;
    }

    @Override
    public List<GetUserDTO> findAllUser() {
        List<User> users = hola.findAll();
        List<GetUserDTO> usersList = new ArrayList<>();

        users.forEach(user -> {
            GetUserDTO findUser = new GetUserDTO();
            findUser.setUserName(user.getUserName());

            usersList.add(findUser);
        });

        return usersList;
    }
}
