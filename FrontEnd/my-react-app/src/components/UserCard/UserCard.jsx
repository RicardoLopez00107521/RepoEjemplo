import React from 'react';
import styles from './User.Card.module.css'

function UserCard({ firstName, lastName, phoneNumber, addres, userRoles }) {
    return (
        <div className={styles.card}>
            <h2 className={styles.title}>
                {firstName} {lastName}
            </h2>
            <p className={styles.text}>📞 Teléfono: {phoneNumber}</p>
            <p className={styles.text}>🏠 Dirección: {addres}</p>
            <div>
                <p className={styles.text}>🎖️ Roles:</p>
                {userRoles.map((role, index) => (
                    <span key={index} className={styles.role}>{role}</span>
                ))}
            </div>
        </div>
    );
}

export default UserCard;