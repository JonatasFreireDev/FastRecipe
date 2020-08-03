import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { LoginRegisterStack } from '../../interface/IRoutes';

const Register: React.FC<StackScreenProps<LoginRegisterStack, 'Register'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> Register</Text>
        <Button title="Search" onPress={() => navigation.goBack()} />
      </View>
    </>
  );
};

export default Register;
