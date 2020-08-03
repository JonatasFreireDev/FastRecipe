import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { RecipeStack } from '../../../interface/IRoutes';

const PersonPerfil: React.FC<StackScreenProps<RecipeStack, 'PersonPerfil'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> PersonPerfil</Text>
      </View>
    </>
  );
};

export default PersonPerfil;
