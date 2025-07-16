import React from 'react';
import styles from './Role.Card.module.css'

function RoleCard({ roleName, userRoles }) {
    return (
        <div className={styles.card}>
            <h2 className={styles.title}>
                {roleName}
            </h2>
            <div>
                <p className={styles.user}>👤 Users:</p>
                {userRoles.map((user, index) => (
                    <span key={index} className={styles.user}>{user}</span>
                ))}
            </div>
        </div>
    );
}

export default RoleCard;