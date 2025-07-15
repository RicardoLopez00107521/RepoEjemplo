package com.example.demo.controllers;

import com.example.demo.domain.dtos.GetUserDTO;
import com.example.demo.domain.dtos.NewUserDTO;
import com.example.demo.domain.entities.User;
import com.example.demo.services.UserService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/user")
public class UserController {

    private final UserService userService;

    public UserController(UserService userService) {
        this.userService = userService;
    }

    @PostMapping("/new-user")
    public ResponseEntity<String> newUser(@RequestBody NewUserDTO newUserDTO) {
        User findUser = userService.findUserByUserName(newUserDTO.getUserName());

        if (findUser != null) {
            return ResponseEntity.badRequest().build();
        }

        userService.addUser(newUserDTO);

        return ResponseEntity.ok("User added successfully!");
    }

    @GetMapping("/get-all-users")
    public ResponseEntity<List<GetUserDTO>> findUser() {

        List<GetUserDTO> usersList = userService.findAllUser();

        if (usersList.isEmpty()) {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(usersList);
    }

    @GetMapping("/findUserById/{userId}")
    public ResponseEntity<GetUserDTO> findUser(@PathVariable Integer userId) {

        User findUser = userService.findUserById(userId);

        if (findUser == null) {
            return ResponseEntity.notFound().build();
        }

        GetUserDTO userInfo = userService.userInfo(findUser);

        return ResponseEntity.ok(userInfo);
    }
}
