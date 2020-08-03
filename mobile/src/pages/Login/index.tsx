import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { LoginRegisterStack } from '../../interface/IRoutes';

const Login: React.FC<StackScreenProps<LoginRegisterStack, 'Login'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> Login</Text>
        <Button
          title="Search"
          onPress={() => navigation.navigate('Register')}
        />
      </View>
    </>
  );
};

export default Login;
