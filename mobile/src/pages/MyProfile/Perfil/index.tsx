import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { MyProfileStack } from '../../../interface/IRoutes';

const Perfil: React.FC<StackScreenProps<MyProfileStack, 'Perfil'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> Perfil</Text>
      </View>
    </>
  );
};

export default Perfil;
